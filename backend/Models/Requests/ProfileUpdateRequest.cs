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

namespace backend.Models.Requests
{
    public class ProfileUpdateRequest
    {
        public string Email { get; set; }
        public string Phone { get; set; } = null;
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? Gender { get; set; } = null;
        public string? Country { get; set; } = null;
        public string? Address { get; set; } = null;
        public string? AboutMe { get; set; } = null;
    }
}
