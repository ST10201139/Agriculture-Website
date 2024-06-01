// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// welcomeAnimation.js
document.addEventListener('DOMContentLoaded', (event) => {
    const welcomeTitle = document.querySelector('.welcome-section h1');
    welcomeTitle.classList.add('animate-bounce');
});