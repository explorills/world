import { createRoot } from 'react-dom/client'
import { Toaster } from 'sonner'

import App from './App.tsx'

import "./main.css"
import "./styles/theme.css"
import "./index.css"

createRoot(document.getElementById('root')!).render(
  <>
    <App />
    <Toaster position="top-center" theme="dark" />
  </>
)
