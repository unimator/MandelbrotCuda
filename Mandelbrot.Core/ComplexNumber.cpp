#include <cmath>
#include "ComplexNumber.h"

bool inline ComplexNumber<float>::operator==(const ComplexNumber<float>& operand) const
{
	static const auto comparing_precision = 0.000001f;
	return fabs(real_ - operand.real_) < comparing_precision && fabs(imaginary_ - operand.imaginary_) < comparing_precision;
}

bool inline ComplexNumber<double>::operator==(const ComplexNumber<double>& operand) const
{
	static const auto comparing_precision = 0.000000001;
	return fabs(real_ - operand.real_) < comparing_precision && fabs(imaginary_ - operand.imaginary_) < comparing_precision;
}
