using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductTest.DataAccess.Features.ProductFeatures.Commands;
using ProductTest.DataAccess.Features.ProductFeatures.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProductTestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        static Random rnd = new Random();
        public ProductController()
        {

        }

        [HttpGet]
        public ActionResult Index()
        {
            return Ok("Index Method Execute Successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await UploadImageToAzureBlob();

           // return Ok();
            return Ok(await Mediator.Send(new GetAllProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));
        }

        // POST: ProductController/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: ProductController/Modify/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Modify(int id, UpdateProductCommand command)
        {
            if (id <= 0 || (id != command.Id))
            {
                try
                {
                    return BadRequest();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Ok(await Mediator.Send(command));
        }


        // DELETE: ProductController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                try
                {
                    return BadRequest();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }));
        }


        static async Task<bool> UploadImageToAzureBlob()
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=grk22333teststorage;AccountKey=2dIviFMUjkOvt6570w/taPGb4OoaIqca2mdefdsXRq8ElrqMaGkW4K1iI5xowVIuZVZmb/rLIlUd+AStWQmo9A==;EndpointSuffix=core.windows.net";
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            string containerName = "newappimages";
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            string imageName = "Image_From_Web_API_" + rnd.Next(1, 1000).ToString() + ".jpg";
            BlobClient blobClient = containerClient.GetBlobClient(imageName);


            BlobHttpHeaders blobHttpHeader = new BlobHttpHeaders();

            blobHttpHeader.ContentType = "image/jpeg";

            using (FileStream imageFile = System.IO.File.OpenRead("D:\\Professional\\BirthDay_Invitation.jpg"))
            {
                var res = await blobClient.UploadAsync(imageFile, blobHttpHeader);
                if (res != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
