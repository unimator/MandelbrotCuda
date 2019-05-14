#include <cuda_runtime_api.h>
#include <cstdint>

//__device__ uint32_t CalculateColor(uint32_t steps_to_escape, uint32_t max_steps)
//{
//	auto red = (2 << 6) - 1;
//	auto green = red << 8;
//	auto blue = green << 8;
//
//	return static_cast<uint32_t>((max_steps - steps_to_escape) / static_cast<float>(max_steps) * red);
//}
