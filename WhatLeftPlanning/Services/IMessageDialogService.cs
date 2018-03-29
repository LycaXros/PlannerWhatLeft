namespace WhatLeftPlanning.Services
{
    public interface IMessageDialogService
    {
        MessageDialogResult ShowOkCancelDialog(string text, string title);
        void ShowDialog(string text, string title);


    }
}