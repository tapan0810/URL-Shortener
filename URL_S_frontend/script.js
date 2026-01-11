const API_URL = "http://localhost:5166/api/urls";

async function shortenUrl() {
  const input = document.getElementById("longUrl");
  const button = document.querySelector("button");
  const result = document.getElementById("result");
  const shortUrlEl = document.getElementById("shortUrl");

  if (!input.value.trim()) {
    Swal.fire("Oops!", "Please enter a valid URL", "warning");
    return;
  }

  button.classList.add("loading");

  try {
    const response = await fetch(API_URL, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ originalUrl: input.value })
    });

    if (!response.ok) throw new Error();

    const data = await response.json();

    shortUrlEl.href = data.shortUrl;
    shortUrlEl.textContent = data.shortUrl;

    result.classList.remove("hidden");

    Swal.fire({
      icon: "success",
      title: "Short URL Created!",
      text: "Your link is ready to share 🚀",
      timer: 1800,
      showConfirmButton: false
    });

  } catch {
    Swal.fire("Error", "Backend is not reachable", "error");
  } finally {
    button.classList.remove("loading");
  }
}

function copyToClipboard() {
  const url = document.getElementById("shortUrl").textContent;
  navigator.clipboard.writeText(url);

  Swal.fire({
    icon: "success",
    title: "Copied!",
    text: "Short URL copied to clipboard",
    timer: 1200,
    showConfirmButton: false
  });
}
