﻿using System;
using System.Collections.Generic;

namespace ProductQueryWebApi.Migrations;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
}
