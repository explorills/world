import { useEffect, useRef } from 'react'

interface VideoBackgroundProps {
  videoSrc?: string
}

export function VideoBackground({ videoSrc = '' }: VideoBackgroundProps) {
  const videoRef = useRef<HTMLVideoElement>(null)

  useEffect(() => {
    if (videoRef.current && videoSrc) {
      // Optimize playback for smoother performance on low-end devices
      const video = videoRef.current
      
      // Request lower power mode for background video
      if ('preservesPitch' in video) {
        video.preservesPitch = false
      }
      
      video.play().catch(() => {})
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
        preload="auto"
        disablePictureInPicture
        disableRemotePlayback
        className="absolute top-1/2 left-1/2 min-w-full min-h-full w-auto h-auto object-cover"
        style={{
          transform: 'translate(-50%, -50%) translateZ(0)',
          willChange: 'transform',
          backfaceVisibility: 'hidden',
          contain: 'strict',
        }}
      >
        <source src={videoSrc} type="video/mp4" />
      </video>
    </div>
  )
}
