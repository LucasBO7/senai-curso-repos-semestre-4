function ConvertToDate(e) {
  e.type == "text" ? e.type = "date" : null;
}

function ConvertToText(e) {
  console.log(e.type);

  e.type == "date" && !e.value ? e.type = "text" : null;
}