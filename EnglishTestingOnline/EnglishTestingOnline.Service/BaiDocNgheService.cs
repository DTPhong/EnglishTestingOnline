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
    public interface IBaiDocNgheSercive
    {
        BaiDocNghe Add(BaiDocNghe baiDocNghe);
        BaiDocNghe Delete(int id);
        void Update(BaiDocNghe baiDocNghe);
        BaiDocNghe GetById(int id);
        IEnumerable<BaiDocNghe> GetAll();
        void Save();
    }
    public class BaiDocNgheService : IBaiDocNgheSercive
    {
        private IBaiDocNgheRepository _baiDocNgheRepository;
        private IUnitOfWork _unitOfWork;

        public BaiDocNgheService(IBaiDocNgheRepository baiDocNgheRepository, IUnitOfWork unitOfWork)
        {
            this._baiDocNgheRepository = baiDocNgheRepository;
            this._unitOfWork = unitOfWork;
        }

        public BaiDocNghe Add(BaiDocNghe baiDocNghe)
        {
            return _baiDocNgheRepository.Add(baiDocNghe);
        }

        public BaiDocNghe Delete(int id)
        {
            return _baiDocNgheRepository.Delete(id);
        }

        public IEnumerable<BaiDocNghe> GetAll()
        {
            return _baiDocNgheRepository.GetAll();
        }

        public BaiDocNghe GetById(int id)
        {
            return _baiDocNgheRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(BaiDocNghe baiDocNghe)
        {
            _baiDocNgheRepository.Update(baiDocNghe);
        }
    }
}
