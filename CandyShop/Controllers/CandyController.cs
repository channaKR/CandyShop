using CandyShop.Data;
using CandyShop.Models;
using CandyShop.Models.Domain;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Xml.Linq;

namespace CandyShop.Controllers
{
    public class CandyController : Controller
    {
        private readonly CandyContext candyContext;
        public CandyController(CandyContext candyContext)
        {
                this.candyContext = candyContext;   
        }
        [HttpGet]
        public IActionResult AddCandy()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Index() {

            var candy=await candyContext.Candies.ToListAsync();//Recived Database Data
            return View(candy);  
        }
        [HttpPost]
        public async Task<IActionResult> AddCandy(AddCandyViewModel addCandyViewModel)
        {
          
            var candy = new Candy()
            {
                Id = Guid.NewGuid(),
                Name = addCandyViewModel.Name,
                Price=addCandyViewModel.Price,  
                Description = addCandyViewModel.Description,
                addDate = addCandyViewModel.addDate


        };
            await candyContext.Candies.AddAsync(candy);
            await candyContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //View Data
        [HttpGet]
        public  async Task<IActionResult> viewCandy(Guid Id)
        {   
            var candy=await candyContext.Candies.FirstOrDefaultAsync(x=>x.Id== Id);
            if (candy != null)
            {
                var viewModel = new UpdateCandyViewModel()
                {
                    Id = candy.Id,
                    Name = candy.Name,
                    Price = candy.Price,
                    Description = candy.Description,
                    addDate = candy.addDate


                };
                return await Task.Run(()=> View("viewCandy", viewModel));
            }

            return Redirect("Index");
        }

        [HttpPost]
        public async Task<IActionResult> viewCandy(UpdateCandyViewModel updateCandyViewModel)
        {
            var candy = await candyContext.Candies.FindAsync(updateCandyViewModel.Id);
            if (candy!=null)
            {
                candy.Price= updateCandyViewModel.Price;
                candy.Name = updateCandyViewModel.Name;
                candy.Price = updateCandyViewModel.Price;
                candy.Description = updateCandyViewModel.Description;
                candy.addDate = updateCandyViewModel.addDate;
                await candyContext.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateCandyViewModel model)
        {
            var deletedata =await candyContext.Candies.FindAsync(model.Id);
            if (deletedata != null)
            {
                candyContext.Candies.Remove(deletedata);
                await candyContext.SaveChangesAsync();
               
            }
            return RedirectToAction("Index");

        }


       

    }
 

}
