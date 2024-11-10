using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cloud2bPOE.Data; 
using Cloud2bPOE.Models; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud2bPOE.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Order/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Products = await _context.Product.ToListAsync();
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order, List<OrderItem> orderItems)
        {
            if (ModelState.IsValid && orderItems.Count > 0)
            {
                order.OrderDate = DateTime.Now;
                order.TotalAmount = orderItems.Sum(item => item.Quantity * item.UnitPrice);
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                foreach (var item in orderItems)
                {
                    item.OrderID = order.OrderID; // Link OrderItems to the Order
                    _context.OrderItems.Add(item);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Products = await _context.Product.ToListAsync();
            return View(order);
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Include(o => o.Customer)
                .ToListAsync();
            return View(orders);
        }
    }
}
