namespace Domain.Abstractions
{
	/// <summary>
	/// This class represents the configuration of success and failure response.
	/// </summary>
	public class Result
	{
		public bool IsSuccess { get; }

		public bool IsFailure => !IsSuccess;

		public Error Error { get; }

		public Result(bool isSuccess, Error error)
		{
			if (isSuccess && error != Error.None ||
				!isSuccess && error == Error.None)
			{
				throw new ArgumentException("Invalid error", nameof(error));
			}

			IsSuccess = isSuccess;
			Error = error;
		}

		public static Result Success() => new(true, Error.None);

		public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

		public static Result Failure(Error error) => new(false, error);

		public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
	}

	public class Result<TValue> : Result
	{
		private readonly TValue? _value;

		public Result(TValue? value, bool isSuccess, Error error)
			: base(isSuccess, error)
		{
			_value = value;
		}

		public TValue Value => IsSuccess 
			? _value! 
			: throw new InvalidOperationException("Value can not be accessed when IsSuccess is false.");
	}

	public static class ResultExtensions
	{
		public static T Match<T>(
			this Result result,
			Func<T> onSuccess,
			Func<Error, T> onFailure)
		{
			return result.IsSuccess ? onSuccess() : onFailure(result.Error);
		}

		public static T Match<T, TValue>(
			this Result<TValue> result,
			Func<TValue, T> onSuccess,
			Func<Error, T> onFailure)
		{
			return result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Error);
		}
	}
}
