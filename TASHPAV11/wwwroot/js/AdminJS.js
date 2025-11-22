function TeachersOnly()
{
    let filter = 'true';
    let rows = document.querySelectorAll("#AllPeopleTable tr");

    rows.forEach(row => {
        // skip header

       
        let cell = row.querySelector("td:nth-child(7)"); // Family Name column
        if (!cell) return; // skip header
        let text = cell.innerText.toLowerCase();


        row.style.display = text.includes(filter) ? "" : "none";
    });
}
