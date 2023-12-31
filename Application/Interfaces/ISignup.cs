﻿using Application.DTOs.Requests;
using Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface ISignup
{
    Task<UserLoggedDTO> SignupAsync(UserSignupDTO dto);
}
