// Busca o botão "Filtros" pelo id "filters-visibility-button"
const filterButton = document.getElementById("filters-visibility-button");
// Busca o form cuja visiblidade será manipulada por meio do botão "Filtros"
const formFilters = document.getElementById("filters-form");

const sectionFiltersBox = document.getElementById("filters-section");

// Adiciona um evento de click no botão "Filtros"
filterButton.onclick = () => {
  formFilters.classList.contains("hide-mobile-element")
    ? (
      // Mostra os filtros
      formFilters.classList.replace("hide-mobile-element", "show-mobile-element"),
      sectionFiltersBox.classList.replace("filters-closed", "filters-opened"),
      filterButton.style.backgroundColor = '#b5b5b5'
    )
    : (
      // Esconde os filtros
      formFilters.classList.replace("show-mobile-element", "hide-mobile-element"),
      sectionFiltersBox.classList.replace("filters-opened", "filters-closed"),
      filterButton.style.backgroundColor = 'rgb(215, 215, 215)'
    );
};