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
    public interface IChuDeSercive
    {
        ChuDe Add(ChuDe ChuDe);
        ChuDe Delete(int id);
        void Update(ChuDe ChuDe);
        ChuDe GetById(int id);
        IEnumerable<ChuDe> GetAll();
        void Save();
    }
    public class ChuDeService : IChuDeSercive
    {
        private IChuDeRepository _ChuDeRepository;
        private IUnitOfWork _unitOfWork;

        public ChuDeService(IChuDeRepository ChuDeRepository, IUnitOfWork unitOfWork)
        {
            this._ChuDeRepository = ChuDeRepository;
            this._unitOfWork = unitOfWork;
        }
        public ChuDe Add(ChuDe ChuDe)
        {
            return _ChuDeRepository.Add(ChuDe);
        }

        public ChuDe Delete(int id)
        {
            return _ChuDeRepository.Delete(id);
        }

        public IEnumerable<ChuDe> GetAll()
        {
            return _ChuDeRepository.GetAll();
        }

        public ChuDe GetById(int id)
        {
            return _ChuDeRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ChuDe ChuDe)
        {
            _ChuDeRepository.Update(ChuDe);
        }
    }
}

