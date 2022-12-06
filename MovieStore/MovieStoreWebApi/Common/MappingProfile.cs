using System.Linq;
using Application.ActorOperations.Queries.GetActorDetail;
using Application.GenreOperations.Commands.CreateGenre;
using Application.GenreOperations.Commands.UpdateGenre;
using Application.GenreOperations.Queries.GetGenreDetail;
using Application.GenreOperations.Queries.GetGenres;
using Application.MovieOperations.Commands.UpdateMovie;
using Applications.MovieOperations.Commands.CreateMovie;
using Applications.MovieOperations.Queries.GetMovieDetail;
using Applications.MovieOperations.Queries.GetMovies;
using AutoMapper;
using MovieStoreWebApi.Application.ActorOperations.Commands.CreateActor;
using MovieStoreWebApi.Application.ActorOperations.Commands.UpdateActor;
using MovieStoreWebApi.Application.ActorOperations.Queries.GetActors;
using MovieStoreWebApi.Application.CustomerOperations.Commands.CreateCustomer;
using MovieStoreWebApi.Application.DirectorOperations.Commands.CreateDirector;
using MovieStoreWebApi.Application.DirectorOperations.Commands.UpdateDirector;
using MovieStoreWebApi.Application.DirectorOperations.Queries.GetDirectorDetail;
using MovieStoreWebApi.Application.OrderOperations.Commands.CreateOrder;
using MovieStoreWebApi.Application.OrderOperations.Commands.UpdateOrder;
using MovieStoreWebApi.Application.OrderOperations.Queries.GetOrderDetail;
using MovieStoreWebApi.Entities;
using static MovieStoreWebApi.Application.DirectorOperations.Queries.GetDirectors.GetDirectorQuery;

namespace MovieStoreWebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Movie, MovieDetailModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<CreateMovieModel, Movie>();
            CreateMap<UpdateMovieModel, Movie>();

            CreateMap<Genre , GetViewModel>();
            CreateMap<Genre, GenreDetailModel>();
            CreateMap<CreateGenreModel, Genre >();
            CreateMap<UpdateGenreModel, Genre >();
            
            CreateMap<CreateActorModel, Actor>();
            CreateMap<Actor, ActorDetailModel>();
            CreateMap<Actor, ActorViewModel>();
            CreateMap<UpdateActorModel, Actor>();

            CreateMap<CreateCustomerModel,Customer>();

            CreateMap<CreateDirectorModel,Director>();
            CreateMap<UpdateDirectorModel,Director>();
            CreateMap<Director, DirectorViewModel>();
            CreateMap<Director, DirectorDetailModel>();
            
             CreateMap<CreateOrderModel, Order>();
             CreateMap<UpdateOrderModel, Order>();
             CreateMap<Customer, OrderViewModel>()
             .ForMember(dest => dest.NameSurname, opt => opt.MapFrom(src => src.Name + " " + src.LastName))
             .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Orders.Select(s => s.Movie.Title)))
             .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Orders.Select(s => s.Movie.Price)))
             .ForMember(dest => dest.PurchasedDate, opt => opt.MapFrom(src => src.Orders.Select(s => s.purchasedTime)));
        }
    }
}