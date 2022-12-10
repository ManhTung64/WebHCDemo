using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectWeb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Record> Records { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedCategory(builder);
            SeedRecord(builder);
            SeedTemplate(builder);
            SeedUser(builder);
            SeedRole(builder);
            SeedUserRole(builder);
        }

        private void SeedUser(ModelBuilder builder)
        {
            var customer = new IdentityUser
            {
                Id = "1",
                UserName = "customer@gmail.com",
                Email = "customer@gmail.com",
                NormalizedUserName = "customer@gmail.com",
                EmailConfirmed = true
            };

            var hasher = new PasswordHasher<IdentityUser>();

            customer.PasswordHash = hasher.HashPassword(customer, "123456");
            builder.Entity<IdentityUser>().HasData(customer);
        }

        private void SeedRole(ModelBuilder builder)
        {
            var customer = new IdentityRole
            {
                Id = "customer",
                Name = "customer",
                NormalizedName = "customer"
            };
            builder.Entity<IdentityRole>().HasData(customer);
        }

        private void SeedUserRole(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "1",
                    RoleId = "customer"
                });
        }

        private void SeedCategory(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Nghị định" },
                new Category() { Id = 2, Name = "Quyết định" },
                new Category() { Id = 3, Name = "Thông báo" }
                );
        }

        private void SeedRecord(ModelBuilder builder)
        {
            builder.Entity<Record>().HasData(
                new Record() { id = 1, document_name = "Đơn xin thôi việc", document_id = "11", book_number = "b-123", version = "#123", last_fix = 15, CategoryId = 1, Dear_to = "Trưởng phòng nhân sự", Destination = "Phòng nhân sự", Content = "Đơn xin thôi việc", signed_day = new DateTime(2015, 02, 02), Image = "nghidinh1.jpg" },
                new Record() { id = 2, document_name = "Đơn xin giảm học phí", document_id = "12", book_number = "b-789", version = "#789", last_fix = 25, CategoryId = 2, Dear_to = "Hiệu trưởng", Destination = "Trường đại học Greenwich", Content = "Miễn giảm học phí", signed_day = new DateTime(2019, 03, 04), Image = "quyetdinh1.jpg" },
                new Record() { id = 3, document_name = "Đơn xin xác nhận học bổng", document_id = "13", book_number = "b-456", version = "#456", last_fix = 20, CategoryId = 3, Dear_to = "Chủ tịch tỉnh\nChủ tịch xã\nBan lãnh đạo nhà trường", Destination = "Ủy ban nhân dân huyện\nTrường đại học Greenwich", Content = "Đơn xin xác nhận học bổng", signed_day = new DateTime(2017, 02, 02), Image = "thongbao1.png" },
                new Record() { id = 4, document_name = "An toàn thực phẩm", document_id = "14", book_number = "b-132", version = "#132", last_fix = 23, CategoryId = 1, Dear_to = "Các trưởng khoa y tế", Destination = "Các cơ quan, bệnh viên trực thuộc bộ y tế", Content = "Sửa đổi bổ sung một số quy định liên quan đến điều kiện kinh doanh thuộc phạm vi quản lý nhà nước của bộ y tế", signed_day = new DateTime(2018, 05, 04), Image = "nghidinh2.png" },
                new Record() { id = 5, document_name = "Đơn xin nghỉ học", document_id = "15", book_number = "b-321", version = "#321", last_fix = 10, CategoryId = 2, Dear_to = "Giáo viên chủ nhiệm\nHiệu trưởng", Destination = "Trường đại học Greenwich", Content = "Đơn xin nghỉ học", signed_day = new DateTime(2016, 02, 02), Image = "quyetdinh2.jpg" },
                new Record() { id = 6, document_name = "Thông báo nghỉ lễ", document_id = "16", book_number = "b-345", version = "#345", last_fix = 12, CategoryId = 3, Dear_to = "Giám đốc các cơ quan đoàn thể trong nước", Destination = "Các cơ quan đoàn thể tổ chức hoạt động dưới quyền quản lí của nhà nước", Content = "Thông báo nghỉ lễ quốc khánh", signed_day = new DateTime(2022, 06, 09), Image = "thongbao2.png" }
                );
        }

        private void SeedTemplate(ModelBuilder builder)
        {
            builder.Entity<Template>().HasData(
                new Template() { Id = 1, modalId = "m1", url = "https://cms.luatvietnam.vn/uploaded/Images/Original/2019/04/11/to-khai-dang-ky-ket-hon-chuan_1104141938.jpg", name = "kethon", title = "Mẫu đơn đăng ký kết hôn", description1 = "Tờ khai đăng ký kết hôn hiện nay được áp dụng theo quy định tại Thông tư 04/2020/TT-BTP quy định thi hành một số điều của Luật Hộ tịch, có hiệu lực từ ngày 16/7/2020. Theo đó, nếu đi làm thủ tục đăng ký kết hôn, hai người nam nữ phải khai vào tờ khai đăng ký kết hôn để cơ quan có thẩm quyền xác định thông tin nhân thân, nơi cư trú, đã kết hôn mấy lần rồi... Qua đó, làm căn cứ để tiến hành làm thủ tục đăng ký kết hôn cho hai người.", description2 = "" },
                new Template() { Id = 2, modalId = "m2", url = "https://cdn.thuvienphapluat.vn/phap-luat/2022/202201/PVQ/thang7/220719/305-1.jpg", name = "kethon", title = "Mẫu đơn ly hôn", description1 = "Giấy quyết định ly hôn hay được gọi bằng một tên gọi gần gũi hơn là trích lục ly hôn - là một giấy tờ pháp lý do cơ quan có thẩm quyền ở đây là Tòa án Nhân dân sau khi hoàn thành việc giải quyết ly hôn theo thủ tục ly hôn đơn phương theo quy định pháp luật về tố tụng dân sự và hôn nhân gia dình. Giấy quyết định ly hôn có hiệu lực pháp lý tương đương với bản án quyết định ly hôn của Tòa án. Chính vì vậy, khi xảy ra trường hợp bản án quyết định ly hôn của Tòa án không còn tồn tại thì giấy quyết định ly hôn là một văn bản có hiệu lực pháp lý thay thế.", description2 = "" },
                new Template() { Id = 3, modalId = "m3", url = "https://sanketoan.vn/public/library_staff/25094/images/tailieu2/5(16).PNG", name = "quyen", title = "Quyết định bổ nhiệm", description1 = "Bổ nhiệm là việc giao cho một người giữ một chức vụ trong bộ máy nhà nước bằng quyết định của cá nhân hay của cơ quan nhà nước có thẩm quyền. Bổ nhiệm là việc giao cho một người giữ chức vụ trong bộ máy nhà nước bằng quyết định của cá nhân hay của cơ quan nhà nước có thẩm quyền. Bổ nhiệm là việc làm mang tính chất quyền lực nhà nước của người giữ chức vụ nhất định để góp phần kiện toàn và củng cố bộ máy nhà nước, đảm bảo cho bộ máy nhà nước hoạt động có hiệu quả và hiệu lực trên thực tế.", description2 = "" },
                new Template() { Id = 4, modalId = "m4", url = "http://1001vieclam.com/bieu-mau-nhan-su/wp-content/uploads/2017/08/de-xuat-bo-nhiem-nhan-su-1.jpg", name = "quyen", title = "Đề xuất bổ nhiệm nhân sự", description1 = "Mẫu phiếu đề xuất bổ nhiệm cán bộ là mẫu phiếu được gửi tới cơ quan có thẩm quyền để xem xét bổ nhiệm cán bộ. Mẫu phiếu bổ nhiệm cán bộ được nêu rõ thông tin cá nhân của người được bổ nhiệm, lý do bổ nhiệm, ý kiến của phòng nhân sự, ý kiến của ban giám đốc về việc bổ nhiệm cán bộ mới. ", description2 = "" },
                new Template() { Id = 5, modalId = "m5", url = "https://sudospaces.com/ketoanleanh/2020/10/hop-dong-mua-ban-nha-o.jpg", name = "dat", title = "Hợp đồng mua bán nhà ở và chuyển đổi quyền sử dung đất", description1 = "Hợp đồng mua bán nhà ở là sự thoả thuận bằng văn bản giữa bên mua và bên bán, theo đó bên bán có nghĩa vụ chuyển giao nhà ở và quyền sở hữu nhà ở cho bên mua. Bên mua có nghĩa vụ trả tiền cho bên bán đúng thời hạn, địa điểm theo phương thức mà các bên đã thoả thuận trong hợp đồng mua bán nhà ở.", description2 = "Đối tượng của hợp đồng mua bán nhà ở là ngôi nhà hoặc diện tích nhà dùng vào việc ở, sinh hoạt hàng ngày của con người. Nhà ở khác với nhà dùng vào mục đích khác như làm văn phòng, trụ sở cơ quan, kho chứa, cửa hàng, cửa hiệu… Nhưng, khi mua bán nhà ở để dùng vào mục đích khác cũng phải tuân theo các quy định của pháp luật về mua bán nhà ở." },
                new Template() { Id = 6, modalId = "m6", url = "https://o.vdoc.vn/data/image/2022/06/09/don-khieu-nai-giai-quyet-tranh-chap-dat-dai-1.jpg", name = "dat", title = "Đơn khiếu nại lấn chiếm đất", description1 = "Theo pháp luật hiện hành, đơn khiếu nại lấn chiếm không gian là loại văn bản được người khiếu nại dùng để khiếu nại về việc lấn chiếm không gian phát sinh khi khoảng không gian nằm trong diện tích đất của mình bị lấn chiếm bất hợp pháp.\r\n\r\nTrên thực tế, việc khiếu nại tranh chấp lối đi chung là một trong những trường hợp phổ biến xảy ra nhất.", description2 = "" },
                new Template() { Id = 7, modalId = "m7", url = "https://o.vdoc.vn/data/image/2022/06/09/don-khieu-nai-giai-quyet-tranh-chap-dat-dai-1.jpg", name = "dat", title = "Đơn khiếu nại lấn chiếm đất", description1 = "Theo pháp luật hiện hành, đơn khiếu nại lấn chiếm không gian là loại văn bản được người khiếu nại dùng để khiếu nại về việc lấn chiếm không gian phát sinh khi khoảng không gian nằm trong diện tích đất của mình bị lấn chiếm bất hợp pháp.\r\n\r\nTrên thực tế, việc khiếu nại tranh chấp lối đi chung là một trong những trường hợp phổ biến xảy ra nhất.", description2 = "" }
                );
        }
    }
}
