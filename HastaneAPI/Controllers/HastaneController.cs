using HastaneAPI.Context;
using HastaneAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HastaneAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HastaneController : ControllerBase
    {

        //Base entity =>ıd,
        //Hastane =>HastaneAd, adres, List<Hasta>
        //Hasta => Adı,Soyadı,string Klinik,Muayene tarihi,Hastane,
        //Hastanecontroller yap getall,getbyıd,create,update,delete endpointleriniz olsun.
        //Yalnız bu işlemlerde DTO(Data transfer object) kullanınız

        private readonly AppDbContext _context;

        public HastaneController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [HttpGet]
        public ActionResult<List<HastaneDTO>> GetAll()
        {
            List<HastaneDTO> hastaneler = _context.Hastane.Select(
                h => new HastaneDTO
                {
                    Id = h.Id,
                    HastaneAd = h.HastaneAd,
                    Adres = h.Adres
                }
            ).ToList();

            if (!hastaneler.Any())
                return NotFound();

            return hastaneler;
        }


        [HttpGet("{id}")]
        public ActionResult<HastaneDTO> Get(int id)
        {
            Hastane hastane = _context.Hastane.Find(id);
            if (hastane == null)
                return NotFound();
            HastaneDTO hastaneDto = new HastaneDTO()
            {
                Id = hastane.Id,
                HastaneAd = hastane.HastaneAd,
                Adres = hastane.Adres
            };
            return Ok(hastaneDto);
        }
        [HttpPost]
        public ActionResult Create(HastaneCreateDToO hastanecreateDTO)
        {
            try
            {
                Hastane hastane = new Hastane();
                hastane.HastaneAd = hastanecreateDTO.HastaneAd;
                hastane.Adres = hastanecreateDTO.Adres;
                _context.Hastane.Add(hastane);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Update(HastaneDTO hastanedto)
        {
            try
            {
                Hastane hastane = _context.Hastane.Find(hastanedto.Id);
                hastane.HastaneAd = hastanedto.HastaneAd;
                hastane.Adres = hastanedto.Adres;
                _context.Hastane.Update(hastane);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            try
            {
                Hastane hastane = _context.Hastane.Find(id);

                if (hastane == null)
                    return NotFound();

                _context.Hastane.Remove(hastane);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message); 
            }

        }


    }
}
