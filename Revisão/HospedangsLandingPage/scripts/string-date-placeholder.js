function ConvertToDate(e) {
  e.type == "text" ? e.type = "date" : null;
}

function ConvertToText(e) {
  e.type == "date" && !e.value ? e.type = "text" : null;
}