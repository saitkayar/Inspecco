﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyManager(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public IResult Add(Company company)
        {
           _companyRepository.Add(company);
            return new SuccessResult("yeni firma eklendi");
        }

        public IResult Delete(Company company)
        {
            _companyRepository.Delete(company);
            return new SuccessResult("firma silindi");
        }

        public IDataResult<Company> Get(Expression<Func<Company, bool>> filter)
        {
            _companyRepository.Get(filter);
            return new SuccessDataResult<Company>("firma getirildi");
        }

        public IDataResult<List<Company>> GetAll(Expression<Func<Company, bool>> filter = null)
        {
           
            return new SuccessDataResult<List<Company>>(_companyRepository.GetAll(filter),"firmalar getirildi");
        }

        public IDataResult<List<Company>> GetByDetail(Expression<Func<Company, bool>> filter = null)
        {
            return new SuccessDataResult<List<Company>>(_companyRepository.GetCompanyDetail(filter), "firmalar getirildi");
        }

        public IResult Update(Company company)
        {
            _companyRepository.Update(company);
            return new SuccessResult("güncelleme oldu");
        }
    }
}