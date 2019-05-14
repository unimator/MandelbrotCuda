#pragma once
#include <cstdint>
#include "ComplexNumber.h"
#include <cstdio>
#include <cuda_runtime_api.h>
#include "colorCalc.cuh"

template <typename TNumber>
__global__ void CheckPoint(const ComplexNumber<TNumber> origin, const TNumber scale_x, const TNumber scale_y,
                           const size_t width, const size_t height,
                           const uint32_t max_iterations, uint32_t* result);

template <typename TNumber>
__device__ ComplexNumber<TNumber> GetStartPoint(const ComplexNumber<TNumber> origin, const TNumber scale_x,
                                                const TNumber scale_y, const size_t x, const size_t y,
                                                const size_t width, const size_t height);

template <typename TNumber>
__global__ void CheckPoint(const ComplexNumber<TNumber> origin, const TNumber scale_x, const TNumber scale_y,
                           const size_t width, const size_t height,
                           const uint32_t max_iterations, uint32_t* result)
{
	const auto x_index = threadIdx.x + blockIdx.x * blockDim.x;
	const auto y_index = threadIdx.y + blockIdx.y * blockDim.y;

	if (x_index >= width || y_index >= height)
	{
		return;
	}

	const TNumber boundary = 4;
	auto iterations = 0;
	auto start_point = GetStartPoint(origin, scale_x, scale_y, x_index, y_index, width, height);
	auto point = ComplexNumber<TNumber>(start_point);

	while (iterations < max_iterations && point.AbsoluteSquared() < boundary)
	{
		point = point * point + start_point;
		++iterations;
	}

	if(iterations == max_iterations)
	{
		*(result + y_index * height + x_index) = 0xffffffff;
	} else
	{
		*(result + y_index * height + x_index) = CalculateColor<TNumber>(iterations, max_iterations);
	}
}

template <typename TNumber>
__device__ ComplexNumber<TNumber> GetStartPoint(const ComplexNumber<TNumber> origin,
                                                const TNumber scale_x, const TNumber scale_y, const size_t x,
                                                const size_t y,
                                                const size_t width, const size_t height)
{
	TNumber re = origin.GetReal() + static_cast<TNumber>(x) / static_cast<TNumber>(width) * scale_x - scale_x / 2.0;
	TNumber im = origin.GetImaginary() + static_cast<TNumber>(y) / static_cast<TNumber>(height) * scale_y - scale_y / 2.0;

	return ComplexNumber<TNumber>(re, im);
}
