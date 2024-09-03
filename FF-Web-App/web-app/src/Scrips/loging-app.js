//Seccion de cambios de colorez de los botones de arriba
const logingBtn = document.getElementById("logingbtn");

const createUserBtn = document.getElementById("createbtn");

const SubirbotonLoging = () => {
  logingBtn.classList.toggle("-translate-y-1");
  logingBtn.classList.toggle("shadow-md");
  logingBtn.classList.toggle("shadow-gray-900");

  logingBtn.classList.toggle("hover:-translate-y-1");
  logingBtn.classList.toggle("hover:shadow-md");
  logingBtn.classList.toggle("hover:shadow-gray-900");

  createUserBtn.classList.toggle("-translate-y-1");
  createUserBtn.classList.toggle("shadow-md");
  createUserBtn.classList.toggle("shadow-gray-900");
};

const SubirbotonCreate = () => {
  createUserBtn.classList.toggle("-translate-y-1");
  createUserBtn.classList.toggle("shadow-md");
  createUserBtn.classList.toggle("shadow-gray-900");

  createUserBtn.classList.toggle("hover:-translate-y-1");
  createUserBtn.classList.toggle("hover:shadow-md");
  createUserBtn.classList.toggle("hover:shadow-gray-900");

  logingBtn.classList.toggle("-translate-y-1");
  logingBtn.classList.toggle("shadow-md");
  logingBtn.classList.toggle("shadow-gray-900");
};

logingBtn.addEventListener("click", SubirbotonLoging);
createUserBtn.addEventListener("click", SubirbotonCreate);
