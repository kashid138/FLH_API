using Application.Carousel.Commands;
using Application.Carousel.Queries;
using Application.Login.Commands;
using Application.Mail.Commands;
using Application.Posts.Commands;
using Application.Posts.Queries;
using Application.Registration.Commands;
using Application.Registration.Queries;
using Application.TravelCards.Commands;
using Application.TravelCards.Queries;
using Application.Visitors.Commands;
using Application.VisitorsCount.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minimal_Api.Abstractions;
using Minimal_Api.Filters;

namespace Minimal_Api.EndpointDefinations
{
    public class PostEndpointDefinations : IEndpointDefinations
    {
        private readonly IConfiguration _configuration;

        public PostEndpointDefinations(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public void RegisterEndpoints(WebApplication app)
        {
            var posts = app.MapGroup("/api/posts");
            var carousel = app.MapGroup("/api/carousel");
            var travelcard = app.MapGroup("/api/travelcard");
            //var user = app.MapGroup("/api/user");
            var user = app.MapGroup("/api/user");
            var login = app.MapGroup("/api/login");
            var visitor = app.MapGroup("/api/visitor");
            var mail = app.MapGroup("/api/mail");



            #region posts

            posts.MapGet("/{id}", GetPostById)
           .WithName("GetPostById");
             
            posts.MapPost("/", CreatePost)
                .AddEndpointFilter<PostValidationsFilter>();

            posts.MapGet("/", GetAllPosts);

            posts.MapPut("/{id}", UpdatePost)
                .AddEndpointFilter<PostValidationsFilter>();

            posts.MapDelete("/{id}", DeletePost);
            #endregion posts

            #region Carousel
            //Carousel start

            app.MapPost("File/Upload", (HttpRequest req) =>
            {
                if (!req.Form.Files.Any())
                    return Results.BadRequest("Select one");

                foreach (var file in req.Form.Files)
                {
                    string projectDirectory = Directory.GetCurrentDirectory();
                    string uploadPath = Path.Combine(projectDirectory, "Docs/carousel", file.FileName);

                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Results.Ok("Success");
            });


            carousel.MapGet("/{id}", GetCarouselById)
           .WithName("GetCarouselById");

            carousel.MapPost("/", CreateCarousel)
                 .AddEndpointFilter<CarouselValidationsFilter>();

            //app.MapGet("/api/carousel", async (IMediator mediator) =>
            //{
            //    var getCommand = new GetAllCarousel();
            //    var carousel = await mediator.Send(getCommand);
            //    return Results.Ok(carousel);
            //});

            carousel.MapGet("/", GetAllCarausel);


            carousel.MapPut("/{id}", UpdateCarousel)
                .AddEndpointFilter<CarouselValidationsFilter>();

            carousel.MapDelete("{id}", DeleteCarousel);

            ////Carousel End
            #endregion

            #region Travel Card

            app.MapPost("File/Upload/travelcard", (HttpRequest req) =>
            {
                if (!req.Form.Files.Any())
                    return Results.BadRequest("Select one");

                foreach (var file in req.Form.Files)
                {
                    string projectDirectory = Directory.GetCurrentDirectory();
                    string uploadPath = Path.Combine(projectDirectory, "Docs/travelcards", file.FileName);

                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Results.Ok("Success");
            });


            travelcard.MapGet("/{id}", GetTravelCardById)
           .WithName("GetTravelCardById");

            travelcard.MapPost("/", CreateTravelCard)
                 .AddEndpointFilter<TravelCardValidationsFilter>();


            travelcard.MapGet("/", GetAllTravelCard);


            travelcard.MapPut("/{id}", UpdateTravelCard)
                .AddEndpointFilter<TravelCardValidationsFilter>();

            travelcard.MapDelete("{id}", DeleteTravelCard);

            #endregion


            #region User Registration

            user.MapGet("/{id}", GetNewUserById).WithName("GetNewUserById");


            user.MapPost("/", CreateUser)
                .AddEndpointFilter<UserRegistrationValidationsFilter>();

            user.MapGet("/", GetAllUsers);

            user.MapDelete("{id}", DeleteUser);

            user.MapGet("/count", UsersCount);

            #endregion


            #region Login 
            login.MapPost("/", Login);
            #endregion

            #region Visitor 
            visitor.MapPost("/", VisitorCount);
            visitor.MapGet("/", GetAllVisitorsByDate);

            #endregion

            #region Mail 
            mail.MapPost("/", SendMail);

            #endregion
        }

        #region Methods
        #region Post
        private async Task<IResult> GetPostById(IMediator mediator, int id) 
            {
                var getPost = new GetPostById { PostId = id };
                var post = await mediator.Send(getPost);
                return Results.Ok(post);
            }
        private async Task<IResult> CreatePost(IMediator mediator, Post post)
        {
            var createPost = new CreatePosts { PostContent = post.Content };
            var createdPost = await mediator.Send(createPost);
            return Results.CreatedAtRoute("GetPostById", new { createdPost.Id }, createdPost);
        }

        private async Task<IResult> GetAllPosts(IMediator mediator)
        {
            var getCommand = new GetAllPosts();
            var posts = await mediator.Send(getCommand);
            return TypedResults.Ok(posts);
        }

        private async Task<IResult> UpdatePost(IMediator mediator, Post post, int id)
        {
            var updatePost = new UpdatePosts { PostId = id, PostContent = post.Content };
            var updatedPost = await mediator.Send(updatePost);
            return Results.Ok(updatedPost);
        }

        private async Task<IResult> DeletePost(IMediator mediator, int id)
        {
            var deletePost = new DeletePost { PostId = id };
            await mediator.Send(deletePost);
            return TypedResults.NoContent();
        }
        #endregion Post

        #region Carousel
        private async Task<IResult> GetCarouselById(IMediator mediator, int id)
        {
            var getCarousel = new GetCarouselById { CarouselId = id };
            var carousel = await mediator.Send(getCarousel);
            return Results.Ok(carousel);
        }

        private async Task<IResult> CreateCarousel(IMediator mediator, CarouselN carousel)
        {
            var createCarousel = new CreateCarousel { Carouselurl = carousel.url, Carouseltitle = carousel.title, Carouseldescription = carousel.description };
            var createdCarousel = await mediator.Send(createCarousel);
            return Results.CreatedAtRoute("GetCarouselById", new
            {
                createdCarousel.id
            }, createdCarousel);
        }


        private async Task<IResult> GetAllCarausel(IMediator mediator)
        {
            var getCommand = new GetAllCarousel();
            var carouselList = await mediator.Send(getCommand);

            string baseUrl = _configuration["BaseUrl"];

            foreach (var carousel in carouselList)
            {
                //carousel.url = "http://localhost:5145/docs/carousel/" + carousel.url;
                carousel.url = $"{baseUrl}/docs/carousel/{carousel.url}";

            }

            return Results.Ok(carouselList);
        }


        private async Task<IResult> UpdateCarousel(IMediator mediator, CarouselN carousel, int id)
        {
            var updateCarousel = new UpdateCarousel { CarouselId = id, url = carousel.url, title = carousel.title, description = carousel.description };
            var updatedCarousel = await mediator.Send(updateCarousel);
            return Results.Ok(updatedCarousel);
        }

        private async Task<IResult> DeleteCarousel(IMediator mediator, int id)
        {
            var deleteCarousel = new DeleteCarousel { CarouselId = id };
            await mediator.Send(deleteCarousel);
            return Results.NoContent();
        }

        #endregion Carousel

        #region Travel Card
        private async Task<IResult> GetTravelCardById(IMediator mediator, int id)
        {
            var getTravelCard = new GetTravelCardsById { TravelcardId = id };
            var travelCard = await mediator.Send(getTravelCard);

            if (travelCard != null)
            {
                // Update the URL of the travel card
                travelCard.url = "http://localhost:5145/docs/travelcards/" + travelCard.url;

                return Results.Ok(travelCard);
            }
            else
            {
                return Results.NotFound("Travel card not found");
            }
        }

        private async Task<IResult> CreateTravelCard(IMediator mediator, TravelCard travelcard)
        {
            var createtravelcard = new CreateTravelCard { Travelcardurl = travelcard.url, Travelcardtitle = travelcard.title, Travelcarddescription = travelcard.description }; 
            var createdtravelcard = await mediator.Send(createtravelcard);
            return Results.CreatedAtRoute("GetTravelCardById", new
            {
                createdtravelcard.id
            }, createdtravelcard);
        }
        private async Task<IResult> GetAllTravelCard(IMediator mediator)
        {
            var getCommand = new GetAllTravelCards();
            var travelcardList = await mediator.Send(getCommand);

            // Update the URL of each carousel item
            foreach (var tavelcard in travelcardList)
            {
                tavelcard.url = "http://localhost:5145/docs/travelcards/" + tavelcard.url;
            }

            return Results.Ok(travelcardList);
        }
        private async Task<IResult> UpdateTravelCard(IMediator mediator, TravelCard travelcard, int id)
        {
            var updatetravelcard = new UpdateTravelCard { TravelcardId = id, url = travelcard.url, title = travelcard.title, description = travelcard.description };
            var updatedtravelcard = await mediator.Send(updatetravelcard);
            return Results.Ok(updatedtravelcard);
        }
        private async Task<IResult> DeleteTravelCard(IMediator mediator, int id)
        {
            var deletetravelcard = new DeleteTravelCard { TravelcardId = id };
            await mediator.Send(deletetravelcard);
            return Results.NoContent();
        }

        #endregion Travel Card

        #region User
        private async Task<IResult> GetNewUserById(IMediator mediator, int id)
        {
            var getuser = new GetUserByID { userid = id };
            var user = await mediator.Send(getuser);
            return Results.Ok(user);
        }

        private async Task<IResult> CreateUser(IMediator mediator, UserRegistration user)
        {
            var createuser = new CreateUser { firstName = user.firstName, lastName = user.lastName, contact=user.contact, email=user.email , password = user.password};
            var createduser = await mediator.Send(createuser);
            return Results.CreatedAtRoute("GetNewUserById", new { id = createduser.userid }, createduser);

        }
        private async Task<IResult> GetAllUsers(IMediator mediator)
        {
            var getCommand = new GetAllUsers();
            var userslist = await mediator.Send(getCommand);
            return Results.Ok(userslist);
        }

        private async Task<IResult> DeleteUser(IMediator mediator, int id)
        {
            var deleteuser = new DeleteUser { userid = id };
            await mediator.Send(deleteuser);
            return Results.NoContent();
        }

      

        #endregion

        public async Task<IResult> Login(IMediator mediator, UserLogin login)
        {

            var loginCommand = new CheckLogin { Email = login.Email, Password = login.Password };
            var token = await mediator.Send(loginCommand);

            if (token == null)
            {
                return null;
            }

            return Results.Ok(token);

        }


        #region Visitor
        //public async Task<IResult> VisitorCount(IMediator mediator)
        //{
        //    var command = new CreateVisitorCount();
        //    var visitorCount = await mediator.Send(command);
        //    return Results.Ok(visitorCount);
        //}
        public async Task<IResult> VisitorCount(IMediator mediator, [FromBody] CreateVisitorCount command)
        {
            if (command == null || string.IsNullOrEmpty(command.UserIdentifier))
            {
                return Results.BadRequest("User identifier is required.");
            }

            // Send the command to MediatR to process the visitor count
            var visitorCount = await mediator.Send(command);

            return Results.Ok(visitorCount);
        }

        //private async Task<IResult> GetAllVisitorsByDate(IMediator mediator)
        //{
        //    var getCommand = new GetVisitorCountByDate();
        //    var vc = await mediator.Send(getCommand);
        //    return TypedResults.Ok(vc);
        //}

        async Task<IResult> GetAllVisitorsByDate(IMediator mediator, [FromBody] CreateVisitorCount command)
        {
            if (command == null || string.IsNullOrEmpty(command.UserIdentifier))
            {
                return Results.BadRequest("User identifier is required.");
            }

            // Send the command to MediatR to process the visitor count
            var visitorCount = await mediator.Send(command);
            return Results.Ok(visitorCount);
        }

        #endregion

        #region Counts
        public async Task<IResult> UsersCount(IMediator mediator)
        {
            var command = new GetAllUsersCount();
            var userCount = await mediator.Send(command);
            return Results.Ok(userCount);
        }
        #endregion


        #region Mail
        private async Task<IResult> SendMail(IMediator mediator, SendMail sm)
        {
            var mail = new SendEmailCommand {From = sm.From, To =sm.To, Body = sm.Body, Subject = sm.Subject };
            await mediator.Send(mail);
            return Results.Ok(mail);

        }
        #endregion

        #endregion

    }
}

