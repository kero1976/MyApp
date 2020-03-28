﻿using MyApp.Domain.src.ValueObjects.SettinItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.src.ValueObjects.SettingItems
{
    public sealed　class Comment : SettingItem
    {
        public Comment(string value) : base(value, "コメント")
        {

        }
    }
}
