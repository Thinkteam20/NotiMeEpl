using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EplTeamsController: BaseApiController
    {
        
        [HttpGet("teams")]
        public async Task<ActionResult<List<EplTeam>>> GetAllTeam()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = null;

            // HtmlDocument doc = await web.Load("https://www.premierleague.com/tables");
            await Task.Run(() =>
            {
                doc = web.Load("https://www.theguardian.com/football/premierleague/table");
            });
            var EplTeams =  doc.DocumentNode.SelectNodes("//span[@class='team-name']");
            var IconUrl = doc.DocumentNode.SelectNodes("//img[@class='team-crest']");

            List<EplTeam> teams = new List<EplTeam>();
            if(EplTeams != null && IconUrl != null)
            {
                for(int i = 0; i < EplTeams.Count; i++){
                    EplTeam obj = new EplTeam
                    {
                        Id = i,
                        TeamName = EplTeams[i].InnerText,
                        ImageUrl = IconUrl[i].Attributes["src"].Value
                    };
                    teams.Add(obj);
                }
            }
            return teams;
        }
    }
}