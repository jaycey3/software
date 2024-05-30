document.getElementById('addStep').addEventListener('click', function () {
    let stepCount = document.querySelectorAll('#steps .step').length;
    let stepContainer = document.createElement('div');
    stepContainer.classList.add('step');
    stepContainer.innerHTML = `<label asp-for="Steps">Stap ${stepCount + 1}</label>
                                       <textarea asp-for="Steps" name="Steps[${stepCount}].Description" class="form-control" rows="3"></textarea>
                                       <input asp-for="Steps" type="hidden" name="Steps[${stepCount}].Order" value="${stepCount + 1}" />`;
    document.getElementById('steps').appendChild(stepContainer);
});

document.getElementById('addIngredient').addEventListener('click', function () {
    let ingredientCount = document.querySelectorAll('#ingredients .ingredient').length;
    let ingredientContainer = document.createElement('div');
    ingredientContainer.classList.add('input-group', 'ingredient');

    let ingredientOptions;

    ingredients.forEach(function (ingredient) {
        ingredientOptions += `<option value="${ingredient.id}">${ingredient.title}</option>`;
    });

    let select = `<select asp-for="Ingredients[${ingredientCount}].IngredientId" class="form-select form-select-sm">
    ${ingredientOptions}
    </select>`

    ingredientContainer.innerHTML = `${select}
                        <input asp-for="Ingredients[0].Quantity" type="number" class="form-control">
                            <select asp-for="Ingredients[0].Unit" class="form-select form-select-sm">
                                <option value="Gram">Gram</option>
                                <option value="Milliliter">Milliliter</option>
                                <option value="Stuks">Stuks</option>
                                <option value="Theelepel">Theelepel</option>
                                <option value="Eetlepel">Eetlepel</option>
                            </select>`;
    document.getElementById('ingredients').appendChild(ingredientContainer);
});