﻿using CommonLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Logic
{
    public class VenueDisability
    {
        public static List<DTO.VenueDisabilityDTO> GetList(int venueId)
        {
            using (var db = new DatabaseContent())
            {
            
                var list = (from vd in db.VenueDisabilities
                            join dd in db.Disabilities on vd.Disability equals dd.Id
                            join ld in db.DisabilityLevel on vd.Level equals ld.Id
                            where vd.Id == venueId
                            select new DTO.VenueDisabilityDTO {
                                Id = vd.Id,
                                VenueId = vd.VenueId,
                                Disability = vd.Disability,
                                Level = vd.Level,
                                DisabilityDescription = dd.Description,
                                LevelDisabilityDescription = ld.Description,
                                UrlToIcon = ld.UrlToImage                                
                            }).ToList();
                return list;
            }
            
        }

        public static StatusResult Create(string Name)
        {
            using (var db = new DatabaseContent())
            {
                var venueDisability = new Database.Venue_disability()
                {

                    
                };
                db.VenueDisabilities.Add(venueDisability);
                db.SaveChanges();
                return new StatusResult() { Message = "Venue has been added!", Success = true, ReturnId = venueDisability.Id };
            }
        }



    }

   
}
