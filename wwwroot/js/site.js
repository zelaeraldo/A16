document.getElementById('faqLink').addEventListener('click', function (e) {
    e.preventDefault();
    window.location.href = "https://localhost:7060/FAQs";
});

document.getElementById('categoriesLink').addEventListener('click', function (e) {
    e.preventDefault();
    window.location.href = "https://localhost:7060/EventCategories";
});
document.querySelectorAll('.ticket-btn').forEach(button => {
    button.addEventListener('click', function (e) {
        e.preventDefault();
        window.open('https://localhost:7060/Tickets', '_blank');
    });
});