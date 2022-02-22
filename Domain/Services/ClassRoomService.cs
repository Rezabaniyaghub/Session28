﻿using AutoMapper;
using DataAccess;
using DataAccess.Entity;
using Domain.Abstracts;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class ClassRoomService : IClassRoomService
    {
        #region [Ctor]
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;
        public ClassRoomService(IClassRoomRepository classRoomRepository, IMapper mapper, ISchoolRepository schoolRepository)
        {
            _classRoomRepository = classRoomRepository;
            _mapper = mapper;
            _schoolRepository = schoolRepository;
        }
        #endregion

        #region [Methods]
        public List<ClassRoomModel> GetAll(int schooId) =>
           _mapper.Map<List<ClassRoomModel>>(_classRoomRepository.GetAll(schooId));

        public ClassRoomModel GetById(int id) =>
            _mapper.Map<ClassRoomModel>(_classRoomRepository.GetById(id));

        public ClassRoomModel GetNewModelForCreate(int schooId)
        {
            return new ClassRoomModel
            {
                SchoolId = schooId
            };
        }

        public (string Message, bool IsSuccess) Insert(ClassRoomModel model)
        {
            var entity = _mapper.Map<ClassRoom>(model);
            return _classRoomRepository.Insert(entity);
        }


        public (string Message, bool IsSuccess) Delete(int Id) =>
          _classRoomRepository.Delete(Id);

        public (string Message, bool IsSuccess) Update(ClassRoomModel model)
        {
            if (model.Id < 0)
                return ("Id Is Not Valid!", false);
            var result = _classRoomRepository.Update(_mapper.Map<ClassRoom>(model));
            return result;
        }
        #endregion
    }
}
