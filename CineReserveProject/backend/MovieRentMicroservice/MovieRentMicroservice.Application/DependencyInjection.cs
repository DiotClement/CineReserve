namespace MovieRentMicroservice.Application
{
	using FluentValidation;
	using Microsoft.Extensions.DependencyInjection;
	using System.Reflection;

	/// <summary>
	/// This class represents the dependy injection from the application layer into the api (Presentation Layer).
	/// </summary>
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services) 
		{
			Assembly assembly = typeof(DependencyInjection).Assembly;

			services.AddMediatR(configuration =>
				configuration.RegisterServicesFromAssembly(assembly));

			services.AddValidatorsFromAssembly(assembly);

			return services;
		}
	}
}
