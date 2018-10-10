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
    public interface ILoaiBaiDocNgheService
    {
        LoaiBaiDocNghe Add(LoaiBaiDocNghe loaiBaiDocNghe);

        LoaiBaiDocNghe Delete(int id);

        void Update(LoaiBaiDocNghe loaiBaiDocNghe);

        IEnumerable<LoaiBaiDocNghe> GetAll();

        LoaiBaiDocNghe GetById(int id);

        void Save();
    }
    public class LoaiBaiDocNgheService : ILoaiBaiDocNgheService
    {
        private ILoaiBaiDocNgheRepository _loaiBaiDocNgheRepository;
        private IUnitOfWork _unitOfWork;

        public LoaiBaiDocNghe Add(LoaiBaiDocNghe loaiBaiDocNghe)
        {
            return _loaiBaiDocNgheRepository.Add(loaiBaiDocNghe);
        }

        public LoaiBaiDocNghe Delete(int id)
        {
            return _loaiBaiDocNgheRepository.Delete(id);
        }

        public IEnumerable<LoaiBaiDocNghe> GetAll()
        {
            return _loaiBaiDocNgheRepository.GetAll();
        }

        public LoaiBaiDocNghe GetById(int id)
        {
            return _loaiBaiDocNgheRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(LoaiBaiDocNghe loaiBaiDocNghe)
        {
            _loaiBaiDocNgheRepository.Update(loaiBaiDocNghe);
        }
    }
}
