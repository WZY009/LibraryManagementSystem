using BookMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMS.Controllers {
    abstract class AbstractController : IDisposable {
        protected readonly AppDbContent _context;  //readonly是只读属性
        public AbstractController() {
            _context = new AppDbContent();
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}
