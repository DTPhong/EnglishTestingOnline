using EnglishTestingOnline.Data.Infrastructure;
using EnglishTestingOnline.Data.Respositories;
using EnglishTestingOnline.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Service
{
    public interface IBaiLamService
    {
        BaiLam Add(BaiLam baiLam);
        BaiLam Delete(int id);
        void Update(BaiLam baiLam);
        BaiLam GetById(int id);
        IEnumerable<BaiLam> GetAll();
        IEnumerable<BaiLam> GetAllPaging(int page, int pageSize, out int totalRow);

        IEnumerable<BaiLam> SearchByName(string keyword, int page, int pageSize, out int totalRow);
        void Save();
    }
    public class BaiLamService : IBaiLamService
    {
        private IBaiLamRepository _baiLamRepository;
        private IUnitOfWork _unitOfWork;
        string[] includes = { "ApplicationUser" };
        public BaiLamService(IBaiLamRepository baiLamRepository, IUnitOfWork unitOfWork)
        {
            this._baiLamRepository = baiLamRepository;
            this._unitOfWork = unitOfWork;
        }
        public BaiLam Add(BaiLam baiLam)
        {
            return _baiLamRepository.Add(baiLam);
        }

        public BaiLam Delete(int id)
        {
            return _baiLamRepository.Delete(id);
        }

        public IEnumerable<BaiLam> GetAll()
        {
            return _baiLamRepository.GetAll();
        }

        public BaiLam GetById(int id)
        {
            return _baiLamRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
        
        public IEnumerable<BaiLam> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            var query = _baiLamRepository.GetAll(includes);
            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
        public void Update(BaiLam baiLam)
        {
            _baiLamRepository.Update(baiLam);
        }

        public IEnumerable<BaiLam> SearchByName(string keyword, int page, int pageSize, out int totalRow)
        {
            var query = _baiLamRepository.GetMulti(c => c.HocVien_ID.Equals(keyword));
            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
