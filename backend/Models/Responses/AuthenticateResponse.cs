/**
 * This file is part of the Sandy Andryanto Company Profile Website.
 *
 * @author     Sandy Andryanto <sandy.andryanto404@gmail.com>
 * @copyright  2024
 *
 * For the full copyright and license information,
 * please view the LICENSE.md file that was distributed
 * with this source code.
 */

using backend.Models.Entities;

namespace backend.Models.Responses
{
    public class AuthenticateResponse
    {
        public long Id { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Token { get; set; }

        public int Status { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Email = user.Email;
            Phone = user.Phone;
            Token = token;
            Status = user.Status;
        }
    }
}
