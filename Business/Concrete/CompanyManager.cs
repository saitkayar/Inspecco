using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles ="admin")]
        public IResult Add(Company company)
        {
            var validator = new CompanyValidator();
          validator.Validate(company);
           
        _companyRepository.Add(company);
         
            return new SuccessResult("yeni firma eklendi");
        }
        [Authorize]
        public IResult Delete(Company company)
        {
            _companyRepository.Delete(company);
            return new SuccessResult("firma silindi");
        }
        [Authorize]
        public IDataResult<Company> Get(Expression<Func<Company, bool>> filter)
        {
           
            return new SuccessDataResult<Company>(_companyRepository.Get(filter),"firma getirildi");
        }
        [AllowAnonymous]
        public IDataResult<List<Company>> GetAll(Expression<Func<Company, bool>> filter = null)
        {
           
            return new SuccessDataResult<List<Company>>(_companyRepository.GetAll(filter),"firmalar getirildi");
        }
        [AllowAnonymous]
        public IDataResult<List<CompanyDto>> GetByDetail(Expression<Func<CompanyDto, bool>> filter = null)
        {
            return new SuccessDataResult<List<CompanyDto>>(_companyRepository.GetCompanyDetail(filter), "firmalar getirildi");
        }

        public IResult Update(Company company)
        {
            _companyRepository.Update(company);
            return new SuccessResult("güncelleme oldu");
        }
    }
}
