using BookMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMS.Mappers {
    abstract class AbstractMapper : IDisposable {
        protected readonly AppDbContent _context;  //readonly是只读属性
        public AbstractMapper() {
            _context = new AppDbContent();
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}
