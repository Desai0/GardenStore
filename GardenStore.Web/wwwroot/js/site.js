document.addEventListener("DOMContentLoaded", () => {
    const filterButtons = document.querySelectorAll("[data-filter]");
    const filterSummary = document.querySelector("#filterSummary");

    filterButtons.forEach((button) => {
        button.addEventListener("click", () => {
            filterButtons.forEach((item) => {
                item.classList.remove("active", "btn-primary");
                item.classList.add("btn-outline-secondary");
                item.setAttribute("aria-pressed", "false");
            });

            button.classList.remove("btn-outline-secondary");
            button.classList.add("active", "btn-primary");
            button.setAttribute("aria-pressed", "true");

            if (filterSummary) {
                filterSummary.textContent = `Выбран фильтр: ${button.dataset.filter}`;
            }
        });
    });
});
