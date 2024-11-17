import Link from 'next/link';

export default function NotFoundPage() {
  return (
    <div className="flex flex-col px-10 py-8">
      <h1 className="text-3xl font-bold text-green-500">Page Not Found</h1>
      <Link href="/" className="hover:underline hover:text-green-500 mt-10">Go to Home</Link>
    </div>
  );
}