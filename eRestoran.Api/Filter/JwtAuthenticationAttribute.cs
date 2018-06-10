using eRestoran.Api.Helper;
using eRestoran.Data.DAL;
using eRestoran.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace eRestoran.Api.Filter
{
    public class JwtAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        public string Realm { get; set; }
        public bool AllowMultiple => false;
        private string AuthTipKorisnika;

        public JwtAuthenticationAttribute()
        {
        }

        public JwtAuthenticationAttribute(TipKorisnika tipKorisnika)
        {
            AuthTipKorisnika = tipKorisnika.ToString();
        }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null || authorization.Scheme != "Bearer")
                return;

            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing Jwt Token", request);
                return;
            }

            var token = authorization.Parameter;
            var principal = await AuthenticateJwtToken(token);

            if (principal == null)
                context.ErrorResult = new AuthenticationFailureResult("Invalid token", request);

            else
                context.Principal = principal;
        }

        public static Korisnik GetKorisnik(AuthenticationHeaderValue authorization)
        {
            var token = authorization.Parameter;
            var simplePrinciple = JwtManager.GetPrincipal(token);

            var identity = simplePrinciple?.Identity as ClaimsIdentity;
            var korisnikIdClaim = identity.FindFirst("korisnikId");
            var korisnikIdValue = korisnikIdClaim?.Value;

            using (var ctx = new MyContext())
            {
                if (int.TryParse(korisnikIdValue, out var korisnikId))
                    return ctx.Korisnici.FirstOrDefault(x => x.Id == korisnikId);
            }

            return null;
        }

        private static bool ValidateToken(string token, string tipKorisnika, out string korisnikId)
        {
            korisnikId = null;

            var simplePrinciple = JwtManager.GetPrincipal(token);
            var identity = simplePrinciple?.Identity as ClaimsIdentity;

            if (identity == null)
                return false;

            if (!identity.IsAuthenticated)
                return false;

            var korisnikIdClaim = identity.FindFirst("korisnikId");
            korisnikId = korisnikIdClaim?.Value;

            if (!String.IsNullOrWhiteSpace(tipKorisnika))
            {
                var tipKorisnikaClaim = identity.FindFirst("tipKorisnika");
                var tokenTipKorisnika = tipKorisnikaClaim?.Value;
                if(tokenTipKorisnika != tipKorisnika)
                {
                    return false;
                }
            }

            if (string.IsNullOrEmpty(korisnikId))
                return false;

            // More validate to check whether username exists in system

            return true;
        }

        protected Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            string korisnikId;

            if (ValidateToken(token, AuthTipKorisnika, out korisnikId))
            {
                // based on username to get more information from database in order to build local identity
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, korisnikId)
                    // Add more claims if needed: Roles, ...
                };

                var identity = new ClaimsIdentity(claims, "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);

                return Task.FromResult(user);
            }

            return Task.FromResult<IPrincipal>(null);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            Challenge(context);
            return Task.FromResult(0);
        }

        private void Challenge(HttpAuthenticationChallengeContext context)
        {
            string parameter = null;

            if (!string.IsNullOrEmpty(Realm))
                parameter = "realm=\"" + Realm + "\"";

            context.ChallengeWith("Bearer", parameter);
        }
    }
}