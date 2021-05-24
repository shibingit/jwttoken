
public static string SignData()
        {
             RSA _rsa;
             _rsa = new RSACryptoServiceProvider(1024);
            SigningCredentials credentials = new SigningCredentials(
               new RsaSecurityKey(_rsa),
               SecurityAlgorithms.RsaSha256Signature);

            var header = new JwtHeader(credentials);

            JwtPayload permClaims = new JwtPayload();

            //var permClaims = new List<Claim>();
            permClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.AddClaim(new Claim("sub", "123456789")); //?? The ID of the agent in the external system
            permClaims.AddClaim(new Claim("email", "shibin@test.com"));
            permClaims.AddClaim(new Claim("iat", DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()));
            permClaims.AddClaim(new Claim("nonce", "sdgsdgsdgdshshhsdhsdh"));
            permClaims.AddClaim(new Claim("given_name", "shibin"));
            permClaims.AddClaim(new Claim("family_name", "Raj"));
              
            var secToken = new JwtSecurityToken(header, permClaims);
            var handler = new JwtSecurityTokenHandler();

            var tokenString = handler.WriteToken(secToken);
            return tokenString;
        }
