using BookMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMS.Mappers {
    abstract class AbstractMapper : IDisposable {
        protected readonly AppDbContent _context;
        public AbstractMapper() {
            _context = new AppDbContent();
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}
