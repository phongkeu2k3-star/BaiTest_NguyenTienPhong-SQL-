using BaiTest_NguyenTienPhong_SQL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaiTest_NguyenTienPhong_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // 1. Lấy danh sách (Đã có - OK)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // 2. Lấy chi tiết 1 người (ĐÂY LÀ HÀM BẠN ĐANG THIẾU)
        // Nếu không có hàm này, ấn nút Sửa sẽ bị lỗi 404
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();
            return user;
        }

        // 3. Thêm người dùng mới
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            user.Id = 0; // Quan trọng: Đặt về 0 để SQL tự sinh ID, tránh lỗi Swagger
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        // 4. Cập nhật thông tin
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id) return BadRequest();
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Users.Any(e => e.Id == id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        // 5. Xóa người dùng
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}