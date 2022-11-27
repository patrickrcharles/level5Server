﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using level5Server.Controllers.Utility;
using level5Server.Models.nftairdrop;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace level5Server.Controllers.nftairdrop
{
    [Route("[controller]")]
    public class NFTAirDropController : Controller
    {
        private readonly nftAirDropContext _context;

        public NFTAirDropController(nftAirDropContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Airdrop()
        //public IActionResult Airdrop()
        {
            //return View(await _context.Nft.ToListAsync());
            return View(await _context.Nft.ToListAsync());
        }
        [Route("viewrequests")]
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ViewRequests()
        //public IActionResult Airdrop()
        {
            //return View(await _context.Nft.ToListAsync());
            return View(await _context.Nftrequest.ToListAsync());
        }

        [HttpPost]
        [Route("[controller]")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> PostRequest()
        {
            try
            {
                string tokenid = Request.Form["tokenId"].ToString() ?? "";
                string requestAddress = Request.Form["requestAddress"].ToString() ?? "";
                string name = "";

                if (!UtilityFunctions.IsValidEthereumAddress(requestAddress))
                {
                    string returnString = "requestAddress : " + requestAddress + "\nis not a valid Ethereum address"; 
                    return BadRequest(returnString);
                }

                int? available = _context.Nft.Where(x => x.TokenId == tokenid).FirstOrDefault().AvailableRequests;
                int? max = _context.Nft.Where(x => x.TokenId == tokenid).FirstOrDefault().MaxRequests;

                if(available <= 0)
                {
                    string returnString = "NFT\nname:" + name + "\ntoken id : " 
                        + tokenid + "\nto : " 
                        + requestAddress + "\nhas "
                        + available + " left. try back next week";
                    return BadRequest(returnString);
                }
                // get name of NFT
                if (_context.Nft.Any(x => x.TokenId == tokenid))
                {
                    name = _context.Nft.Where(x => x.TokenId == tokenid).FirstOrDefault().Name.ToString();
                }
                else
                {
                    name = "not found";
                }

                if (_context.Nftrequest.Where(x => x.RequestAddress.Equals(requestAddress)).Any())
                {
                    //NFTRequest nFTRequest = _context.Nftrequest
                    return Conflict("you already requested : " + name);
                }
                else
                {
                    NFTRequest nftRequest = new NFTRequest();
                    nftRequest.Name = name;
                    nftRequest.TokenId = tokenid;
                    nftRequest.RequestAddress = requestAddress;
                    nftRequest.Transferred = 0;
                    nftRequest.TimeStamp = DateTime.Now;
                    //nftRequest.IpAddress

                    _context.Nftrequest.Add(nftRequest);
                    await _context.SaveChangesAsync();

                    // decrement available requests
                    _context.Nft.Where(x => x.TokenId.Equals(tokenid)).FirstOrDefault().AvailableRequests--;
                    await _context.SaveChangesAsync();

                    string returnString = "Submission request for NFT\nname:" + name + "\ntoken id : " + tokenid + "\nto : " + requestAddress + "\nwas succesful";
                    return Ok(returnString);
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                System.Diagnostics.Debug.WriteLine("----- SERVER : DbUpdateConcurrencyException : " + e);
                return BadRequest();
            }
        }
    }
}
