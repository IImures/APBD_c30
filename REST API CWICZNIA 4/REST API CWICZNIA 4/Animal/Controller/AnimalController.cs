using Microsoft.AspNetCore.Mvc;
using REST_API_CWICZNIA_4.Animal.Controller.Request;
using REST_API_CWICZNIA_4.Animal.Service;

namespace REST_API_CWICZNIA_4.Animal.Controller;

[ApiController]
[Route("api/animals")]
public class AnimalController : ControllerBase
{
   private AnimalService _animalService;
   
   public AnimalController(AnimalService animalService)
   {
       _animalService = animalService;
   }
   
   [HttpGet]
   public IActionResult GetAnimals()
   {
       return Ok(_animalService.GetAll());
   }
   
   [HttpGet("{id}")]
   public IActionResult GetAnimal(int id)
   {
       return Ok(_animalService.GetById(id));
   }
   
   [HttpGet("{id}/records")]
   public IActionResult GetAnimalRecords(int id)
   {
       return Ok(_animalService.GetAnimalRecords(id));
   }
   
   [HttpPut]
   public IActionResult CreateAnimal(AnimalRequest animalRequest)
   {
       _animalService.CreateAnimal(animalRequest);
       return Created();
   } 
   
   [HttpPatch("{id}")]
    public IActionResult UpdateAnimal(long id, AnimalRequest animalRequest)
    {
        return Ok(_animalService.UpdateAnimal(id, animalRequest));
    }
   
   [HttpDelete("{id}")]
   public IActionResult DeleteAnimal(long id)
   {
       _animalService.DeleteAnimal(id);
       return NoContent();
   }
   
}