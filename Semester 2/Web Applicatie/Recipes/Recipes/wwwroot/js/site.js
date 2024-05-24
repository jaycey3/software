document.getElementById('addStep').addEventListener('click', function () {
    let stepCount = document.querySelectorAll('#steps .step').length;
    let stepContainer = document.createElement('div');
    stepContainer.classList.add('step');
    stepContainer.innerHTML = `<label asp-for="Steps">Step ${stepCount + 1}</label>
                                       <input asp-for="Steps" name="Steps[${stepCount}].Description" class="form-control" />
                                       <input asp-for="Steps" type="hidden" name="Steps[${stepCount}].Order" value="${stepCount + 1}" />`;
    document.getElementById('steps').appendChild(stepContainer);
});