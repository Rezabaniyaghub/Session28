using AutoMapper;
using DataAccess.Entity;
using Models;
using System;

namespace Persentetion
{
    public static class MappingConfing
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>

            {
                config.CreateMap<SchoolModel, School>()
                .ForMember(f => f.CreateAt, mf => mf.MapFrom(d=>Convert.ToDateTime (d.CreateDate)));

                config.CreateMap<School, SchoolModel>()
               .ForMember(f => f.CreateDate, mf => mf.MapFrom(d => d.CreateAt == null ? "Register Date not Exsit" 
               : Convert.ToDateTime(d.CreateAt).ToString("yyyy/MMM/dd")));

               
                config.CreateMap<ClassRoomModel, ClassRoom>().ReverseMap();
            }); 
            return mappingConfig;
        }

    }


}

