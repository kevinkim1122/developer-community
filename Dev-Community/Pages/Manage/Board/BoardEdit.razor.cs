﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev_Community.Pages.Manage.Board
{
    public partial class BoardEdit
    {
        [Parameter] public int Seq { get; set; } 

        Models.Board board = new Models.Board();

        bool isEditing = false;
        protected override async Task OnInitializedAsync()
        {
            if (Seq != 0)
            {
                board = await BoardDBService.Get(Seq);
            }
            else
            {
                isEditing = true;
            }
            
        }

        private void Btn_Cancel_Click()
        {
            //JSRuntime.InvokeAsync("alert", "");

            Nav.NavigateTo("Manage/Board/View");
        }

        private void Btn_Save_Click()
        {
            if (isEditing)
            {
                BoardDBService.Add(board);
            }
            else
            {
                BoardDBService.Update(board);
            }
            
            Nav.NavigateTo("Manage/Board/View");
     
        }
    }
}
