#include <windows.h>
#include <cstdint>
#include <cstdio>
#include "ComplexNumber.h"
#include "Mandelbrot.h"

template <typename TNumber>
uint32_t* CalculateMandelbrot(TNumber re, TNumber im, TNumber scale_x, TNumber scale_y, size_t width, size_t height, uint32_t max_iterations);

BOOL WINAPI DllMain(
	_In_ HINSTANCE hinstDLL,
	_In_ DWORD fdwReason,
	_In_ LPVOID lpvReserved
)
{
	return true;
}

extern "C" {

	__declspec(dllexport)
	void FreeMemory(void *ptr)
	{
		if(ptr)
		{
			free(ptr);
		}
	}

	__declspec(dllexport)
	uint32_t* CalculateMandelbrotDouble(const double re, const double im, const double scale_x, const double scale_y, const size_t width,
	                                           const size_t height, const uint32_t max_iterations)
	{
		return CalculateMandelbrot<double>(re, im, scale_x, scale_y, width, height, max_iterations);
	}

	__declspec(dllexport)
	uint32_t* CalculateMandelbrotFloat(const float re, const float im, const float scale_x, const double scale_y, const size_t width,
	                                          const size_t height, const uint32_t max_iterations)
	{
		return CalculateMandelbrot<float>(re, im, scale_x, scale_y, width, height, max_iterations);
	}
}

template <typename TNumber>
uint32_t* CalculateMandelbrot(TNumber re, TNumber im, TNumber scale_x, TNumber scale_y, size_t width, size_t height,
                                     uint32_t max_iterations)
{
#if _DEBUG
	printf("CalculateMandelbrot(%llf, %llf, %llf, %llf, %u, %u, %u)\n", re, im, scale_x, scale_y, width, height, max_iterations);
#endif
	auto origin = ComplexNumber<TNumber>(re, im);
	auto mandelbrot = Mandelbrot<TNumber>(origin, scale_x, scale_y, width, height, max_iterations);
	return mandelbrot.GetData();
}