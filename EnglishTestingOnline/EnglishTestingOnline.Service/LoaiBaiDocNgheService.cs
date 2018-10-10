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
    public interface ILoaiBaiDocNgheSercive
    {
        LoaiBaiDocNghe Add(LoaiBaiDocNghe LoaiBaiDocNghe);
        LoaiBaiDocNghe Delete(int id);
        void Update(LoaiBaiDocNghe LoaiBaiDocNghe);
        LoaiBaiDocNghe GetById(int id);
        IEnumerable<LoaiBaiDocNghe> GetAll();
        void Save();
    }
    public class LoaiBaiDocNgheService : ILoaiBaiDocNgheSercive
    {
        private ILoaiBaiDocNgheRepository _LoaiBaiDocNgheRepository;
        private IUnitOfWork _unitOfWork;

        public LoaiBaiDocNgheService(ILoaiBaiDocNgheRepository LoaiBaiDocNgheRepository, IUnitOfWork unitOfWork)
        {
            this._LoaiBaiDocNgheRepository = LoaiBaiDocNgheRepository;
            this._unitOfWork = unitOfWork;
        }
        public LoaiBaiDocNghe Add(LoaiBaiDocNghe LoaiBaiDocNghe)
        {
            return _LoaiBaiDocNgheRepository.Add(LoaiBaiDocNghe);
        }

        public LoaiBaiDocNghe Delete(int id)
        {
            return _LoaiBaiDocNgheRepository.Delete(id);
        }

        public IEnumerable<LoaiBaiDocNghe> GetAll()
        {
            return _LoaiBaiDocNgheRepository.GetAll();
        }

        public LoaiBaiDocNghe GetById(int id)
        {
            return _LoaiBaiDocNgheRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(LoaiBaiDocNghe LoaiBaiDocNghe)
        {
            _LoaiBaiDocNgheRepository.Update(LoaiBaiDocNghe);
        }
    }
}

