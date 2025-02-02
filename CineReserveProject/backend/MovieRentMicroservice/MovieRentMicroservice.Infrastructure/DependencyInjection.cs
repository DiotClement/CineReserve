namespace MovieRentMicroservice.Infrastructure
{
    using MovieRentMicroservice.Application.Abstractions;
    using MovieRentMicroservice.Infrastructure.Persistance;
    using Microsoft.Extensions.DependencyInjection;

	/// <summary>
	/// This class represents the dependy injection from the infrastructure layer into the api (Presentation Layer).
	/// </summary>
    public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
		{
			services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
			return services;
		}
	}
}
