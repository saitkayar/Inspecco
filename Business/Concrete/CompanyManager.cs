using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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
        private IInvitationService _invitationService;

        public CompanyManager(ICompanyRepository companyRepository, IInvitationService invitationService)
        {
            _companyRepository = companyRepository;
            _invitationService = invitationService;
        }

        public IResult Add(Company company)
        {
        var result=  _companyRepository.Add(company);
            if (result)
            {
               
            }
            return new SuccessResult("yeni firma eklendi");
        }

        public IResult Delete(Company company)
        {
            _companyRepository.Delete(company);
            return new SuccessResult("firma silindi");
        }

        public IDataResult<Company> Get(Expression<Func<Company, bool>> filter)
        {
            
            return new SuccessDataResult<Company>(_companyRepository.Get(filter),"firma getirildi");
        }

        public IDataResult<List<Company>> GetAll(Expression<Func<Company, bool>> filter = null)
        {
           
            return new SuccessDataResult<List<Company>>(_companyRepository.GetAll(filter),"firmalar getirildi");
        }

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
