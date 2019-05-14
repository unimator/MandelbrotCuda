#pragma once
#include "ComplexNumber.h"
#include "calc.cuh"
#include <cstdint>
#include <cstdio>
#include <cuda_runtime_api.h>

template<typename TNumber>
class Mandelbrot final
{
private:
	ComplexNumber<TNumber> origin_;
	TNumber scale_x_, scale_y_;
	size_t width_, height_;

	bool is_initialized_;

	uint32_t max_iterations_;

	void CalculateData();

public:
	Mandelbrot(ComplexNumber<TNumber>, TNumber scale_x, TNumber scale_y, size_t width, size_t height, uint32_t max_iterations);
	~Mandelbrot();

	uint32_t* GetData();
};

template <typename TNumber>
Mandelbrot<TNumber>::Mandelbrot(ComplexNumber<TNumber> origin, TNumber scale_x, TNumber scale_y, const size_t width, const size_t height, const uint32_t max_iterations)
	: origin_(origin), scale_x_(scale_x), scale_y_(scale_y), width_(width), height_(height), is_initialized_(false), max_iterations_(max_iterations)
{

}

template <typename TNumber>
Mandelbrot<TNumber>::~Mandelbrot()
{
}

template <typename TNumber>
uint32_t* Mandelbrot<TNumber>::GetData()
{
	const auto data_size = width_ * height_ * sizeof(uint32_t);
	auto data = static_cast<uint32_t*>(malloc(data_size));
	if(!data)
	{
		printf("malloc failed\n");
		goto Error;
	}
#if _DEBUG
	else
	{
		printf("0x%x (%u) bytes of memory allocated\n", data_size, data_size);
	}
#endif

	uint32_t* dev_data = nullptr;
	cudaError_t cudaStatus;

	cudaStatus = cudaSetDevice(0);
	if (cudaStatus != cudaSuccess)
	{
		printf("cudaSetDevice failed\n");
		goto Error;
	}

	cudaStatus = cudaMalloc(reinterpret_cast<void**>(&dev_data), width_ * height_ * sizeof(uint32_t));
	if (cudaStatus != cudaSuccess)
	{
		printf("cudaMalloc failed\n");
		goto Error;
	}

	const auto threadsCount = 16;
	dim3 threadsPerBlock(threadsCount, threadsCount);
	dim3 numBlocks(width_ / threadsPerBlock.x + 1 - width_ % threadsPerBlock.x / threadsCount,
		height_ / threadsPerBlock.y + 1 - height_ % threadsPerBlock.y / threadsCount);

	CheckPoint<<<numBlocks, threadsPerBlock>>> (origin_, scale_x_, scale_y_, width_, height_, max_iterations_, dev_data);

	cudaStatus = cudaDeviceSynchronize();
	if(cudaStatus != cudaSuccess)
	{
		printf("CheckPoint kernel failed (%s)\n", cudaGetErrorString(cudaStatus));
		goto Error;
	}

	cudaStatus = cudaMemcpy(data, dev_data, height_ * width_ * sizeof(uint32_t), cudaMemcpyDeviceToHost);
	if (cudaStatus != cudaSuccess)
	{
		printf("cudaMemcpy failed (%s)\n", cudaGetErrorString(cudaStatus));
		goto Error;
	}

Error:
	if (dev_data)
	{
		cudaFree(dev_data);
	}

	return data;
}

