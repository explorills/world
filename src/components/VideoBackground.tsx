import { useEffect, useRef } from 'react'

interface VideoBackgroundProps {
  videoSrc?: string
}

export function VideoBackground({ videoSrc = '' }: VideoBackgroundProps) {
  const videoRef = useRef<HTMLVideoElement>(null)

  useEffect(() => {
    if (videoRef.current && videoSrc) {
      videoRef.current.play().catch(() => {})
    }
  }, [videoSrc])

  if (!videoSrc) {
    return (
      <div className="fixed inset-0 -z-10 bg-gradient-to-br from-black via-gray-900 to-black" />
    )
  }

  return (
    <div className="fixed inset-0 -z-10 overflow-hidden bg-black">
      <video
        ref={videoRef}
        autoPlay
        loop
        muted
        playsInline
        className="absolute top-1/2 left-1/2 min-w-full min-h-full w-auto h-auto -translate-x-1/2 -translate-y-1/2 object-cover"
      >
        <source src={videoSrc} type="video/mp4" />
      </video>
    </div>
  )
}
