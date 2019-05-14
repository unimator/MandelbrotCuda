#pragma once

#ifdef __CUDACC__
#define CUDA_CALLABLE_MEMBER __host__ __device__
#else
#define CUDA_CALLABLE_MEMBER
#endif

template<typename TNumber> class ComplexNumber
{
private:
	TNumber real_;
	TNumber imaginary_;
public:
	CUDA_CALLABLE_MEMBER ComplexNumber();
	CUDA_CALLABLE_MEMBER ComplexNumber(const ComplexNumber<TNumber>& number);
	CUDA_CALLABLE_MEMBER ComplexNumber(TNumber real, TNumber imaginary);

	CUDA_CALLABLE_MEMBER TNumber GetReal() const;
	CUDA_CALLABLE_MEMBER void SetReal(TNumber real);

	CUDA_CALLABLE_MEMBER TNumber GetImaginary() const;
	CUDA_CALLABLE_MEMBER void SetImaginary(TNumber imaginary);

	CUDA_CALLABLE_MEMBER TNumber AbsoluteSquared() const;

	CUDA_CALLABLE_MEMBER ComplexNumber<TNumber> operator+() const;
	CUDA_CALLABLE_MEMBER ComplexNumber<TNumber> operator+(const ComplexNumber<TNumber>& operand) const;
	CUDA_CALLABLE_MEMBER void operator+=(const ComplexNumber<TNumber>& operand);

	CUDA_CALLABLE_MEMBER ComplexNumber<TNumber> operator-() const;
	CUDA_CALLABLE_MEMBER ComplexNumber<TNumber> operator-(const ComplexNumber<TNumber>& operand) const;
	CUDA_CALLABLE_MEMBER void operator-=(const ComplexNumber<TNumber>& operand);

	CUDA_CALLABLE_MEMBER ComplexNumber<TNumber> operator*(const ComplexNumber<TNumber>& operand) const;
	CUDA_CALLABLE_MEMBER void operator*=(const ComplexNumber<TNumber>& operand);

	CUDA_CALLABLE_MEMBER bool operator==(const ComplexNumber<TNumber>& operand) const;
	CUDA_CALLABLE_MEMBER bool operator!=(const ComplexNumber<TNumber>& operand) const;

	CUDA_CALLABLE_MEMBER bool operator>(const ComplexNumber<TNumber>& operand) const;
	CUDA_CALLABLE_MEMBER bool operator>=(const ComplexNumber<TNumber>& operand) const;
	CUDA_CALLABLE_MEMBER bool operator<(const ComplexNumber<TNumber>& operand) const;
	CUDA_CALLABLE_MEMBER bool operator<=(const ComplexNumber<TNumber>& operand) const;
};

template <typename TNumber>
CUDA_CALLABLE_MEMBER ComplexNumber<TNumber>::ComplexNumber()
	: ComplexNumber(TNumber(), TNumber())
{	
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER ComplexNumber<TNumber>::ComplexNumber(TNumber real, TNumber imaginary)
	: real_(real), imaginary_(imaginary)
{
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER ComplexNumber<TNumber>::ComplexNumber(const ComplexNumber<TNumber>& number)
	: real_(number.GetReal()), imaginary_(number.GetImaginary())
{
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER void ComplexNumber<TNumber>::SetReal(TNumber real)
{
	real_ = real;
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER TNumber ComplexNumber<TNumber>::GetReal() const
{
	return real_;
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER void ComplexNumber<TNumber>::SetImaginary(TNumber imaginary)
{
	imaginary_ = imaginary;
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER TNumber ComplexNumber<TNumber>::GetImaginary() const
{
	return imaginary_;
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER TNumber ComplexNumber<TNumber>::AbsoluteSquared() const
{
	return real_ * real_ + imaginary_ * imaginary_;
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER ComplexNumber<TNumber> ComplexNumber<TNumber>::operator+() const
{
	return ComplexNumber<TNumber>(+real_, +imaginary_);
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER ComplexNumber<TNumber> ComplexNumber<TNumber>::operator+(const ComplexNumber<TNumber>& operand) const
{
	return ComplexNumber(real_ + operand.GetReal(), imaginary_ + operand.GetImaginary());
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER void ComplexNumber<TNumber>::operator+=(const ComplexNumber<TNumber>& operand)
{
	real_ += operand.GetReal();
	imaginary_ += operand.GetImaginary();
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER ComplexNumber<TNumber> ComplexNumber<TNumber>::operator-() const
{
	return ComplexNumber<TNumber>(-real_, -imaginary_);
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER ComplexNumber<TNumber> ComplexNumber<TNumber>::operator-(const ComplexNumber<TNumber>& operand) const
{
	return ComplexNumber(real_ - operand.GetReal(), imaginary_ - operand.GetImaginary());
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER void ComplexNumber<TNumber>::operator-=(const ComplexNumber<TNumber>& operand)
{
	real_ -= operand.GetReal();
	imaginary_ -= operand.GetImaginary();
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER ComplexNumber<TNumber> ComplexNumber<TNumber>::operator*(const ComplexNumber<TNumber>& operand) const
{
	auto new_real = real_ * operand.GetReal() - imaginary_ * operand.GetImaginary();
	auto new_imaginary = real_ * operand.GetImaginary() + imaginary_ * operand.GetReal();

	return ComplexNumber(new_real, new_imaginary);
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER void ComplexNumber<TNumber>::operator*=(const ComplexNumber<TNumber>& operand)
{
	real_ = real_ * operand.GetReal() - imaginary_ * operand.GetImaginary();
	imaginary_ = real_ * operand.GetImaginary() + imaginary_ * operand.GetReal();
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER bool ComplexNumber<TNumber>::operator==(const ComplexNumber<TNumber>& operand) const
{
	return real_ == operand.GetReal() && imaginary_ == operand.GetImaginary();
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER bool ComplexNumber<TNumber>::operator!=(const ComplexNumber<TNumber>& operand) const
{
	return !(this == operand);
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER bool ComplexNumber<TNumber>::operator>(const ComplexNumber<TNumber>& operand) const
{
	return this->AbsoluteSquared() > operand.AbsoluteSquared();
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER bool ComplexNumber<TNumber>::operator>=(const ComplexNumber<TNumber>& operand) const
{
	return this->AbsoluteSquared() >= operand.AbsoluteSquared();
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER bool ComplexNumber<TNumber>::operator<(const ComplexNumber<TNumber>& operand) const
{
	return this->AbsoluteSquared() < operand.AbsoluteSquared();
}

template <typename TNumber>
CUDA_CALLABLE_MEMBER bool ComplexNumber<TNumber>::operator<=(const ComplexNumber<TNumber>& operand) const
{
	return this->AbsoluteSquared() <= operand.AbsoluteSquared();
}